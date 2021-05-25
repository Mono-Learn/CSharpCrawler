using CSharpCrawler.Data;
using CSharpCrawler.Models;

namespace CSharpCrawler.Repositories
{
    public class DocumentRepository
    {
        public void Create(Document document)
        {
            using var context = new ApplicationDbContext();
            context.Documents.Add(document);
            context.SaveChanges();
        }

        public Document GetById(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Documents.Find(id);
        }
    }
}
