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
    public class CardTemplateRepository
    {
        readonly IDbContextFactory<DbContextSMFY> _dbContextFactorySMFY;
        readonly IMapper _mapper;
        public CardTemplateRepository(IDbContextFactory<DbContextSMFY> dbContextFactorySMFY, IMapper mapper)
        {
            _dbContextFactorySMFY = dbContextFactorySMFY;
            _mapper = mapper;
        }
        public async Task<List<CardTemplateODTO>> GetCardTemplates()
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                return await _dbContextSMFY.CardTemplates.Select(cardTemplate => _mapper.Map<CardTemplateODTO>(cardTemplate)).ToListAsync();
            }
        }
        public async Task<CardTemplateODTO> GetCardTemplateById(int cardTemplateId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                return _mapper.Map<CardTemplateODTO>(await _dbContextSMFY.CardTemplates.FirstOrDefaultAsync(cardTemplate => cardTemplate.CardTemplateID.Equals(cardTemplateId)));
            }
        }
        public async Task<CardTemplateODTO> AddCardTemplate(CardTemplateIDTO cardTemplateIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                EntityEntry<CardTemplate> newCardTemplate = await _dbContextSMFY.AddAsync(_mapper.Map<CardTemplate>(cardTemplateIDTO));
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardTemplateODTO>(newCardTemplate.Entity);
            }
        }

        public async Task<CardTemplateODTO> UpdateCardTemplate(CardTemplateIDTO cardTemplateIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                CardTemplate updateCardTemplate = _mapper.Map<CardTemplateIDTO, CardTemplate>(cardTemplateIDTO, await _dbContextSMFY.CardTemplates.FirstOrDefaultAsync(cardTemplate => cardTemplate.CardTemplateID.Equals(cardTemplateIDTO.CardTemplateID)));
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardTemplateODTO>(updateCardTemplate);
            }
        }

        public async Task<CardTemplateODTO> DeleteCardTemplate(int cardTemplateId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                CardTemplate deleteCardTemplate = await _dbContextSMFY.CardTemplates.FirstOrDefaultAsync(cardTemplate => cardTemplate.CardTemplateID.Equals(cardTemplateId));
                _dbContextSMFY.Remove(deleteCardTemplate);
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardTemplateODTO>(deleteCardTemplate);
            }
        }
    }
}
