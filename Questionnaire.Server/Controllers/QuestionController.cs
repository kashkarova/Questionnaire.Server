using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Questionnaire.BLL.Models;
using Questionnaire.BLL.Services;
using Questionnaire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService _questionService;
        private IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]QuestionModel question)
        {
            try
            {
                var mappedQuestion = _mapper.Map<Question>(question);
                var createdQuestion = await _questionService.AddQuestionWithAnswers(mappedQuestion);

                var mappedQuestionResult = _mapper.Map<QuestionModel>(createdQuestion);

                return Ok(mappedQuestionResult);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/{questionId}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]string questionId)
        {
            try
            {
                var id = ObjectId.Parse(questionId);

                var question = await _questionService.GetQuestion(id);
                var mappedQuestion = _mapper.Map<QuestionModel>(question);

                return Ok(mappedQuestion);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("/{questionId}/vote")]
        [HttpPut]
        public async Task<IActionResult> Vote([FromRoute]string questionId, [FromBody] string votedAnswerId)
        {
            try
            {
                var parsedQuestionId = ObjectId.Parse(questionId);
                var parsedVotedAnswerId = ObjectId.Parse(votedAnswerId);

                var result = await _questionService.VoteForQuestion(parsedQuestionId, parsedVotedAnswerId);

                var mappedResult = _mapper.Map<List<AnswerDisplayModel>>(result);

                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
