using AutoMapper;
using DbManagment.Context;
using DbManagment.DTOs.Output;
using DbManagment.Entities;
using Microsoft.EntityFrameworkCore;
using DbManagment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbManagment.DTOs.Input;

namespace DbManagment.Schema.Mutation
{
    public class Mutation
    {
        readonly UserRepository _userRepository;
        readonly CardRepository _cardRepository;
        readonly CardTemplateRepository _cardTemplateRepository;
        readonly CardImageRepository _cardImageRepository;
        public Mutation(UserRepository userRepository,
            CardRepository cardRepository,
            CardTemplateRepository cardTemplateRepository,
            CardImageRepository cardImageRepository)
        {
            _userRepository = userRepository;
            _cardRepository = cardRepository;
            _cardTemplateRepository = cardTemplateRepository;
            _cardImageRepository = cardImageRepository;
        }
        #region User
        public async Task<UserODTO> CreateUser(UserIDTO userIDTO)
        {
            return await _userRepository.AddUser(userIDTO);
        }
        public async Task<UserODTO> UpdateUser(UserIDTO userIDTO)
        {
            return await _userRepository.UpdateUser(userIDTO);
        }
        public async Task<UserODTO> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }
        #endregion

        #region Card
        public async Task<CardODTO> CreateCard(CardIDTO cardIDTO)
        {
            return await _cardRepository.AddCard(cardIDTO);           
        }
        public async Task<CardODTO> UpdateCard(CardIDTO cardIDTO)
        {
            return await _cardRepository.UpdateCard(cardIDTO);
        }
        public async Task<CardODTO> DeleteCard(Guid cardId)
        {
            return await _cardRepository.DeleteCard(cardId);
        }
        #endregion

        #region CardTemplate
        public async Task<CardTemplateODTO> CreateCardTemplate(CardTemplateIDTO cardTemplateIDTO)
        {
            return await _cardTemplateRepository.AddCardTemplate(cardTemplateIDTO);
        }
        public async Task<CardTemplateODTO> UpdateCardTemplate(CardTemplateIDTO cardTemplateIDTO)
        {
            return await _cardTemplateRepository.UpdateCardTemplate(cardTemplateIDTO);
        }
        public async Task<CardTemplateODTO> DeleteCardTemplate(int cardTemplateId)
        {
            return await _cardTemplateRepository.DeleteCardTemplate(cardTemplateId);
        }
        #endregion

        #region CardImage
        public async Task<CardImageODTO> CreateCardImage(CardImageIDTO cardImageIDTO)
        {
            return await _cardImageRepository.AddCardImage(cardImageIDTO);
        }
        public async Task<CardImageODTO> UpdateCardImage(CardImageIDTO cardImageIDTO)
        {
            return await _cardImageRepository.UpdateCardImage(cardImageIDTO);
        }
        public async Task<CardImageODTO> DeleteCardImage(int cardImageId)
        {
            return await _cardImageRepository.DeleteCardImage(cardImageId);
        }
        #endregion
    }
}
