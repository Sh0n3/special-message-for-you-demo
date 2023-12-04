using DbManagment.Context;
using DbManagment.DTOs.Output;
using DbManagment.Entities;
using DbManagment.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Schema.Query
{
    public class Query
    {
        readonly UserRepository _userRepository;
        readonly CardRepository _cardRepository;
        readonly CardTemplateRepository _cardTemplateRepository;
        readonly CardImageRepository _cardImageRepository;
        public Query(UserRepository userRepository,
            CardRepository cardRepository,
            CardTemplateRepository cardTemplateRepository,
            CardImageRepository cardImageRepository
            )
        {
            _userRepository = userRepository;
            _cardRepository = cardRepository;
            _cardTemplateRepository = cardTemplateRepository;
            _cardImageRepository = cardImageRepository;
        }

        public async Task<List<UserODTO>> GetUsers() => await _userRepository.GetUsers();
        public async Task<UserODTO> GetUserById(int userId) => await _userRepository.GetUserById(userId);               
        public async Task<List<CardODTO>> GetCards() => await _cardRepository.GetCards();
        public async Task<CardODTO> GetCardById(Guid cardId) => await _cardRepository.GetCardById(cardId);
        public async Task<List<CardTemplateODTO>> GetCardTemplates() => await _cardTemplateRepository.GetCardTemplates();
        public async Task<CardTemplateODTO> GetCardById(int cardTemplateId) => await _cardTemplateRepository.GetCardTemplateById(cardTemplateId);
        public async Task<List<CardImageODTO>> GetCardImages() => await _cardImageRepository.GetCardImages();
        public async Task<CardImageODTO> GetCardImageById(int cardImageId) => await _cardImageRepository.GetCardImageById(cardImageId);

    }
}
