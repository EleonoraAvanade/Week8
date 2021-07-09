using Data_Layer.Context;
using Data_Layer.Models;
using Microsoft.Data.SqlClient;
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
                        Console.WriteLine(ex.Message);
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
        public ICollection<Eroe> GetAll(Utente u)
        {
            List<Eroe> list=null;
            using (var ctx = new FinalFantasyContext())
            {
                list= ctx.Eroi.ToList();
                foreach (Eroe ob in list)
                    if (ob.NickUtente != u.Nick) list.Remove(ob);
            }
            return list;
        }
        public Eroe GetById(int id)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if(id < 0)
                {
                    return null;
                }
                var eroe = ctx.Eroi
                                      .FirstOrDefault(x => x.id == id);
                return eroe;
            }
        }
        public bool Delete(int id)
        {
            Eroe partToDelete;
            //Ricerco il record da cancellare
            try
            {
                using (var ctx = new FinalFantasyContext())
                {
                    if (id < 0)
                    {
                        return false;
                    }
                    partToDelete = ctx.Eroi.Find(id);
                }
                //Cancellazione effettiva
                using (var ctx = new FinalFantasyContext())
                {
                    if (partToDelete == null)
                    {
                        return false;
                    }
                    ctx.Entry<Eroe>(partToDelete).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool Update(Eroe Item, int esperienza)
        {
            Eroe partToUpdate;
            try
            {
                using (var ctx = new FinalFantasyContext())
                {
                    if (Item == null)
                    {
                        return false;
                    }
                    partToUpdate = ctx.Eroi.Find(Item.id);
                }

                using (var ctx = new FinalFantasyContext())
                {
                    partToUpdate.Esperienza = esperienza;
                    partToUpdate.Livello = Item.Livello;
                    ctx.Entry<Eroe>(partToUpdate).State = EntityState.Modified;

                    //Stampa per la verifica dei record modificati
                    ctx.ChangeTracker.DetectChanges();
                    Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

                    ctx.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
