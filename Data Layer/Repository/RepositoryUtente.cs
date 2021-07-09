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
                        Console.WriteLine(ex.Message);
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
        public Utente GetById(string id)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if (id== null)
                {
                    return null;
                }
                var ut = ctx.Utenti
                                      .Include(g => g.eroi)
                                      .FirstOrDefault(x => x.Nick == id);
                return ut;
            }
        }
    }
}
