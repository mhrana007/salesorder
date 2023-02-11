using DAL.DataContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly DatabaseContext _context;
        public OrderRepository(DatabaseContext context) //: base(context)
        {
            _context = context;
        }

        public async Task<TblOrders> CreateAsync(TblOrders entity)
        {
            try
            {
                TblOrders ord = new TblOrders();
                ord.OrderName = entity.OrderName;
                ord.State = entity.State;

                var orderdata = await _context.TblOrders.AddAsync(ord);
                _context.SaveChanges();
                foreach (var item in entity.Windows)
                {
                    TblWindows win = new TblWindows();
                    win.OrderId = orderdata.Entity.Id;
                    win.Quantity = item.Quantity;
                    win.WindowName = item.WindowName;
                    var windata = await _context.TblWindows.AddAsync(win);
                    _context.SaveChanges();
                    //win.SubElements = new List<TblSubElements>();
                    int index = 0;
                    foreach (var itemele in item.SubElements)
                    {
                        index = index + 1;
                        TblSubElements el = new TblSubElements();
                        el.WindowId = windata.Entity.Id;
                        el.ElementNumber = (short)index;
                        el.Type = itemele.Type;
                        el.Width = itemele.Width;
                        el.Height = itemele.Height;
                        await _context.TblSubElements.AddAsync(el);
                        
                    }
                    _context.SaveChanges();
                    //ord.Windows.Add(win);
                }
                return orderdata.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var order = _context.TblOrders.FirstOrDefault(x => x.Id == id);
                _context.Remove(order);
                List<TblWindows> win = new List<TblWindows>();
                win = await _context.TblWindows.Where((x) => x.OrderId == id).ToListAsync();

                foreach (var item in win)
                {
                    item.SubElements = new List<TblSubElements>();
                    item.SubElements = await _context.TblSubElements.Where((x) => x.WindowId == item.Id).ToListAsync();
                    _context.RemoveRange(item.SubElements);
                }
                _context.RemoveRange(win);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteWindowAsync(int id)
        {
            try
            {
                var data = _context.TblWindows.FirstOrDefault(x => x.Id == id);
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteElementAsync(int id)
        {
            try
            {
                var data = _context.TblSubElements.FirstOrDefault(x => x.Id == id);
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TblOrders>> GetAllAsync()
        {
            try
            {
                return await _context.TblOrders.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TblOrders> GetByIdAsync(int Id)
        {
            TblOrders ord = new TblOrders();
            ord = await _context.TblOrders.FirstOrDefaultAsync(x => x.Id == Id);
            ord.Windows = new List<TblWindows>();
            ord.Windows = await _context.TblWindows.Where((x) => x.OrderId == Id).ToListAsync();

            foreach (var item in ord.Windows)
            {
                item.SubElements = new List<TblSubElements>();
                item.SubElements = await _context.TblSubElements.Where((x) => x.WindowId == item.Id).ToListAsync();
            }
            return ord;
        }

        public async Task UpdateAsync(TblOrders entity)
        {
            try
            {
                TblOrders ord = new TblOrders();
                ord.Id = entity.Id;
                ord.OrderName = entity.OrderName;
                ord.State = entity.State;
                 _context.TblOrders.Update(ord);

                List<TblWindows> windows = new List<TblWindows>();
                windows = entity.Windows.Where((x) => x.OrderId == entity.Id).ToList();

                if (windows.Count == 0)
                {
                    List<TblWindows> removewin = new List<TblWindows>();
                    removewin = await _context.TblWindows.Where((x) => x.OrderId == entity.Id).ToListAsync();
                    _context.RemoveRange(removewin);
                }
                else if(windows.Count > 0)
                {
                    _context.TblWindows.UpdateRange(windows);
                }
                foreach (var item in entity.Windows)
                {
                    TblWindows win = new TblWindows();
                    win.OrderId = entity.Id;
                    win.Quantity = item.Quantity;
                    win.WindowName = item.WindowName;
                     await _context.TblWindows.AddAsync(win);
                    //_context.SaveChanges();
                }

                    foreach (var item in entity.Windows)
                {
                    List<TblSubElements> subElements = new List<TblSubElements>();
                    subElements =  item.SubElements.Where((x) => x.WindowId == item.Id).ToList();
                    if (subElements.Count>0)
                    {
                        _context.TblSubElements.UpdateRange(subElements);
                    } else if (subElements.Count == 0)
                    {
                        List<TblSubElements> removeele = new List<TblSubElements>();
                        removeele = await _context.TblSubElements.Where((x) => x.WindowId == item.Id).ToListAsync();
                        _context.RemoveRange(removeele);
                    }
                    //else
                    //{
                        int index = 0;
                        foreach (var itemele in item.SubElements)
                        {
                            index = index + 1;
                            TblSubElements el = new TblSubElements();
                            el.WindowId = item.Id;
                            el.ElementNumber = (short)index;
                            el.Type = itemele.Type;
                            el.Width = itemele.Width;
                            el.Height = itemele.Height;
                            await _context.TblSubElements.AddAsync(el);
                        }

                       // _context.TblSubElements.AddRangeAsync(subElements);
                    //}
                    //_context.TblSubElements.UpdateRange(item.SubElements);
                    //_dbContext.Entry(user).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
