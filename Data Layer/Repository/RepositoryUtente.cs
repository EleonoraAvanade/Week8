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
    public class RepositoryUtente : IRepositoryUtente
    {
        public Utente Create(Utente item)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Utente>(item).State = EntityState.Added;
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

        public ICollection<Utente> GetAll()
        {
            using (var ctx = new FinalFantasyContext())
            {
                return ctx.Utenti.ToList();
            }
        }
    }
}
