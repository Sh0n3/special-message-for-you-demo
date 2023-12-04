using AutoMapper;
using DbManagment.Context;
using DbManagment.DTOs.Input;
using DbManagment.DTOs.Output;
using DbManagment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Repositories
{
    public class CardRepository
    {
        readonly IDbContextFactory<DbContextSMFY> _dbContextFactorySMFY;
        readonly IMapper _mapper;
        public CardRepository(IDbContextFactory<DbContextSMFY> dbContextFactorySMFY, IMapper mapper)
        {
            _dbContextFactorySMFY = dbContextFactorySMFY;
            _mapper = mapper;
        }

        public async Task<List<CardODTO>> GetCards()
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                return await _dbContextSMFY.Cards.Select(card => _mapper.Map<CardODTO>(card)).ToListAsync();
            }
        }
        public async Task<CardODTO> GetCardById(Guid cardId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                return _mapper.Map<CardODTO>(await _dbContextSMFY.Cards.FirstOrDefaultAsync(card => card.CardID.Equals(cardId)));
            }
        }

        public async Task<CardODTO> AddCard(CardIDTO cardIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                EntityEntry<Card> newCard = await _dbContextSMFY.AddAsync(_mapper.Map<Card>(cardIDTO));
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardODTO>(newCard.Entity);
            }
        }

        public async Task<CardODTO> UpdateCard(CardIDTO cardIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                Card updateCard = _mapper.Map<CardIDTO, Card>(cardIDTO, await _dbContextSMFY.Cards.FirstOrDefaultAsync());
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardODTO>(updateCard);
            }
        }

        public async Task<CardODTO> DeleteCard(Guid cardId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                Card deleteCard = await _dbContextSMFY.Cards.FirstOrDefaultAsync();
                _dbContextSMFY.Remove(deleteCard);
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardODTO>(deleteCard);
            }
        }
    }
}
