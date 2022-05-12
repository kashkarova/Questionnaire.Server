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
    [Route("questions")]
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

        [HttpGet("")]
        [ProducesResponseType(typeof(List<QuestionDisplayModel>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var questions = await _questionService.GetQuestionsAsync();
            var mappedQuestionsResult = _mapper.Map<List<QuestionDisplayModel>>(questions);
            return Ok(mappedQuestionsResult);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(QuestionDisplayModel), 200)]
        public async Task<IActionResult> InsertAsync([FromBody] QuestionCreateModel question)
        {
            try
            {
                var mappedQuestion = _mapper.Map<Question>(question);
                var createdQuestion = await _questionService.AddQuestionWithAnswersAsync(mappedQuestion);

                var mappedQuestionResult = _mapper.Map<QuestionDisplayModel>(createdQuestion);

                return Ok(mappedQuestionResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{questionId}")]
        [ProducesResponseType(typeof(QuestionDisplayModel), 200)]
        public async Task<IActionResult> GetAsync([FromRoute] string questionId)
        {
            try
            {
                var id = ObjectId.Parse(questionId);

                var question = await _questionService.GetQuestionAsync(id);
                var mappedQuestion = _mapper.Map<QuestionDisplayModel>(question);

                return Ok(mappedQuestion);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{questionId}/vote/{votedAnswerId}")]
        [ProducesResponseType(typeof(List<AnswerDisplayModel>), 200)]
        public async Task<IActionResult> VoteAsync([FromRoute] string questionId, [FromRoute] string votedAnswerId)
        {
            try
            {
                var parsedQuestionId = ObjectId.Parse(questionId);
                var parsedVotedAnswerId = ObjectId.Parse(votedAnswerId);

                var result = await _questionService.VoteForQuestionAsync(parsedQuestionId, parsedVotedAnswerId);

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
