using Microsoft.EntityFrameworkCore;        //Include
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Models
{
    public class CandyRepository : ICandyRepository
    {
        private readonly AppDbContext _appDbContext;

        public CandyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Candy> GetAllCandy 
        {
            get
            {
                return _appDbContext.Candies
                    .Include(c => c.Category);
            }   
        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                return _appDbContext.Candies
                    .Include(c => c.Category)
                    .Where(x => x.IsOnSale);
            }
        }

        public Candy GetCandyById(int candyId)
        {
            return GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);
        }
    }
}
