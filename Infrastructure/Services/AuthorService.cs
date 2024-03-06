using Domain;

namespace Infrastructure;

public class AuthorService : IAuthorService
{ 
    List<Author>_authors=new List<Author>(); 
 
    public List<Author> GetAuthors(AuthorFilters filter)
{
    List<Author> _filteredAuthors = _authors;

    if (filter.FullName != null)
    {
        _filteredAuthors = _filteredAuthors.Where(a => string.Concat(a.FirstName, a.LastName).ToLower().Trim()
        .Contains(filter.FullName.ToLower().Trim())).ToList();
    }
    if (filter.Nationality != null)
    {
        _filteredAuthors = _filteredAuthors.Where(a=>a.Nationality.ToLower().Trim()
        .Contains(filter.Nationality.ToLower().Trim())).ToList();
    }
    if (filter.BirthYear != null)
    {
        _filteredAuthors = _filteredAuthors.Where(a=>a.BirthDate.Year == filter.BirthYear).ToList();
    }

    return _filteredAuthors;
}

    public void AddAuthor(Author author)
    {
         _authors.Add(author);
        Console.WriteLine("Author successfully added");
    }

    public void DeleteAuthor(int id)
    {
        var model = _authors.FirstOrDefault(a=>a.Id == id);
        if (model == null)
        {
            Console.WriteLine("Author not found");
            return;
        }
       _authors.Remove(model);
       Console.WriteLine("Author deleted successfully");
    }

    public Author GetAuthorByID(int id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);

        if (author == null)
        {
            Console.WriteLine("Author not found");
            return null;
        }   
        return author;
    }

    public void UpdateAuthor(Author author)
    {
        var model = _authors.FirstOrDefault(a=>a.Id == author.Id);
        if (model == null)
        {
            Console.WriteLine("Author not found");
            return;
        } 
        model.FirstName = author.FirstName;
        model.LastName = author.LastName;
        model.BirthDate = author.BirthDate;
        model.Nationality = author.Nationality;
        Console.WriteLine("Author successfully updated");
        return;
    } 

    public List<Author> AllAuthors()
    {
        return _authors;
    }
}
