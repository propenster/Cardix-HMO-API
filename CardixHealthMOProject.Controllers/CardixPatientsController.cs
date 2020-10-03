using CardixHealthMOProject.Core.Entities;
using CardixHealthMOProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardixHealthMOProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardixPatientsController : ControllerBase
    {

        protected readonly ICardixPatientService _cardixPatientService;

        public CardixPatientsController(ICardixPatientService cardixPatientService)
        {
            _cardixPatientService = cardixPatientService;
        }

        /// <summary>
        ///HTTP 
        ///GET: api/cardix_patients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCardixPatients()
        {
            var result = await _cardixPatientService.GetAllCardixPatients();
            return Ok(result);
        } 

        //[Route("[action]/{Id}")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCardixPatientById(int Id)
        {
            var result = await _cardixPatientService.GetCardixPatientById(Id);
            return Ok(result);
        }

        [Route("[action]/{PatientId}")]
        [HttpGet]
        public async Task<IActionResult> GetCardixPatientById(string PatientId)
        {
            var result = await _cardixPatientService.GetCardixPatientByPatientId(PatientId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddNewCardixPatient([FromBody] CardixPatient patient)
        {
            _cardixPatientService.AddCardixPatient(patient);
            return CreatedAtAction(nameof(GetCardixPatientById), patient.Id, patient);
        }

        [HttpPut]
        public void UpdateCardixPatient([FromBody] CardixPatient patient)
        {
             _cardixPatientService.UpdateCardixPatient(patient);
        }

        [HttpDelete]
        public void DeleteCardixPatient(int Id)
        {
            _cardixPatientService.DeleteCardixPatient(Id);
        }

    }
}
