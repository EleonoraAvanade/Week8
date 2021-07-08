using Data_Layer.Context;
using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class RepositoryEroe : IRepositoryEroe
    {
        public Eroe Create(Eroe item)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Eroe>(item).State = EntityState.Added;
                        //ctx.Prodotti.Add(item);
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
            return item;
        }

        public ICollection<Eroe> GetAll()
        {
            using (var ctx = new FinalFantasyContext())
            {
                return ctx.Eroi.ToList();
            }
        }
        
    }
}
