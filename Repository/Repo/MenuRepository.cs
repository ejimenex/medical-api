using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class MenuRepository : IMenu
    {
        readonly MedicalContext _medicalContext;
        public MenuRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        
        public  IEnumerable<Menu> GetMenu(int id)
        {
            var menu= _medicalContext.Menu.Include(c => c.children).OrderBy(c=> c.Order).ToList();
            foreach (var item in menu) {
                if(_medicalContext.RolMenu.Any(x => x.RolId == id && x.Menu == item.name))
                item.display = _medicalContext.RolMenu.FirstOrDefault(x => x.RolId == id && x.Menu == item.name).Permitted;
                if (item.children!=null)
                    foreach (var e in item.children)
                {
                    if (_medicalContext.RolMenu.Any(x => x.RolId == id && x.Menu == e.name))
                        e.display = _medicalContext.RolMenu.FirstOrDefault(x => x.RolId == id && x.Menu == e.name).Permitted;
                }
            }
            menu = menu.Where(c => c.display.Value).ToList();
            foreach (var t in menu)
            {
                t.children = t.children.Where(c => c.display.Value).ToList();
            }
            return  menu.AsEnumerable();
        }
    }
}
