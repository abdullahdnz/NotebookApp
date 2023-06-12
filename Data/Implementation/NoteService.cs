using MyNotebook.Data.Abstract;
using MyNotebook.Models;

namespace MyNotebook.Data.Implementation
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;

        public NoteService(AppDbContext _context)
        {
            this._context = _context;
        }

        public bool Add(Note entity)
        {
            try
            {
                _context.Notes.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var value = this.FindByID(id);
                if (value == null)
                {
                    return false;
                }

                _context.Notes.Remove(value);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Note FindByID(int id)
        {
            return _context.Notes.Find(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes.ToList();
        }

        public bool Edit(Note entity)
        {
            try
            {
                _context.Notes.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
