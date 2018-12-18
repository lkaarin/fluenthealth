using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentHealth.Data.Models;
using FluentHealth.Data.Repositories.Core;
using FluentHealth.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FluentHealth.Web.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly IDiseasesRepository _diseasesRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly ISymptomsRepository _symptomsRepository;
        private readonly IDiagnosesRepositories _diagnosesRepositories;

        public DiseaseController(IDiseasesRepository diseasesRepository, IPersonsRepository personsRepository, ISymptomsRepository symptomsRepository, IDiagnosesRepositories diagnosesRepositories)
        {
            _diseasesRepository = diseasesRepository;
            _personsRepository = personsRepository;
            _symptomsRepository = symptomsRepository;
            _diagnosesRepositories = diagnosesRepositories;
        }

        public IActionResult Create() => View(nameof(Edit), MapEditDiseaseViewModel());

        public IActionResult Edit(short id) => View(MapEditDiseaseViewModel(_diseasesRepository.GetDisease(id)));

        [HttpPost]
        public IActionResult Save(DiseaseViewModel diseaseViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View(diseaseViewModel);
            }
        }
        public IActionResult List() => View(_diseasesRepository.GetDiseases().Select(MapDiseaseViewModel<DiseaseViewModel>).ToList());

        private T MapDiseaseViewModel<T>(Disease disease)
            where T : DiseaseViewModel, new()
        {
            return new T
            {
                DiseaseId = disease.DiseaseId,
                Attachments = disease.Attachments.Select(a => new BaseItemViewModel<short> { Id = a.AttachmentId, Name = a.FileName }).ToList(),
                Diagnoses = disease.Diagnoses.Select(x => MapDiagnosisViewModel(x.Diagnosis)).ToList(),
                Drugs = disease.Drugs.Select(a => new BaseItemViewModel<int> { Id = a.DrugHistoryId, Name = a.Drug.Name }).ToList(),
                EndDate = disease.EndDate,
                Person = MapPersonViewModel(disease.Person),
                StartDate = disease.StartDate,
                Symptoms = disease.Symptoms.Select(x => MapSymptomViewModel(x.Symptom)).ToList(),
            };
        }

        private EditDiseaseViewModel MapEditDiseaseViewModel(Disease disease = null)
        {
            EditDiseaseViewModel diseaseViewModel = disease == null ? new EditDiseaseViewModel() : MapDiseaseViewModel<EditDiseaseViewModel>(disease);

            diseaseViewModel.AvailablePersons = _personsRepository.GetPersons().Select(MapPersonViewModel).ToList();
            diseaseViewModel.AvailableSymptoms = _symptomsRepository.GetSymptoms().Select(MapSymptomViewModel).ToList();
            diseaseViewModel.AvailableDiagnoses = _diagnosesRepositories.GetDiagnoses().Select(MapDiagnosisViewModel).ToList();

            return diseaseViewModel;
        }

        private BaseItemViewModel<short> MapPersonViewModel(Person person)
        {
            return new BaseItemViewModel<short> { Id = person.PersonId, Name = person.FirstName };
        }

        private BaseItemViewModel<short> MapSymptomViewModel(Symptom symptom)
        {
            return new BaseItemViewModel<short> { Id = symptom.SymptomId, Name = symptom.Name };
        }

        private BaseItemViewModel<short> MapDiagnosisViewModel(Diagnosis diagnosis)
        {
            return new BaseItemViewModel<short> { Id = diagnosis.DiagnosisId, Name = diagnosis.Name };
        }
    }
}