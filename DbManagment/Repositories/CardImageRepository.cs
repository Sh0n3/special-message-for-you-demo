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
    public class CardImageRepository
    {
        readonly IDbContextFactory<DbContextSMFY> _dbContextFactorySMFY;
        readonly IMapper _mapper;
        public CardImageRepository(IDbContextFactory<DbContextSMFY> dbContextFactorySMFY, IMapper mapper)
        {
            _dbContextFactorySMFY = dbContextFactorySMFY;
            _mapper = mapper;
        }

        public async Task<List<CardImageODTO>> GetCardImages()
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                return await _dbContextSMFY.CardImages.Select(cardImage => _mapper.Map<CardImageODTO>(cardImage)).ToListAsync();
            }
        }
        public async Task<CardImageODTO> GetCardImageById(int cardImageId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                return _mapper.Map<CardImageODTO>(await _dbContextSMFY.CardImages.FirstOrDefaultAsync(cardImage => cardImage.CardImageID.Equals(cardImageId)));
            }
        }

        public async Task<CardImageODTO> AddCardImage(CardImageIDTO cardImageIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                EntityEntry<CardImage> newCardImage = await _dbContextSMFY.AddAsync(_mapper.Map<CardImage>(cardImageIDTO));
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardImageODTO>(newCardImage.Entity);
            }
        }

        public async Task<CardImageODTO> UpdateCardImage(CardImageIDTO cardImageIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                CardImage updateCardImage = _mapper.Map<CardImageIDTO, CardImage>(cardImageIDTO, await _dbContextSMFY.CardImages.FirstOrDefaultAsync(cardImage => cardImage.CardImageID.Equals(cardImageIDTO.CardImageID)));
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardImageODTO>(updateCardImage);
            }
        }

        public async Task<CardImageODTO> DeleteCardImage(int cardImageId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                CardImage deleteCardImage = await _dbContextSMFY.CardImages.FirstOrDefaultAsync(cardImage => cardImage.CardImageID.Equals(cardImageId));
                _dbContextSMFY.Remove(deleteCardImage);
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<CardImageODTO>(deleteCardImage);
            }
        }
    }
}
