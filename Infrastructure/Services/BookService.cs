using Domain;

namespace Infrastructure;

public class BookService : IBookService
{ 
    List<Book>_books=new List<Book>(); 

    public List<Book> GetBook(BookFilters bookFilter)
    {
        List<Book>_filterBook=_books;   

        if (bookFilter.Title!=null)
        {
            _filterBook=_filterBook.Where(a=>a.Title.ToLower().Trim()
            .Contains(bookFilter.Title.ToLower().Trim())).ToList(); 
        }  

        if (bookFilter.Price!=0)
        {
            _filterBook=_filterBook.Where(a=>a.Price>=bookFilter.Price).ToList();
        }  

        if (bookFilter .PubYear!=0)
        {
            _filterBook=_filterBook.Where(a=>a.PublicationYear.Year==bookFilter.PubYear).ToList();
        }

        return _filterBook;
    }
    public void AddBook(Book book)
    {
      _books.Add(book);   
    }

    public List<Book> AllBooks()
    {
         return _books;
    }

    public void DeleteBook(int id)
    {
        var delete=_books.FirstOrDefault(a=>a.Id==id);
        if (delete==null)
        {
            System.Console.WriteLine("Book not found"); 
            return;
        } 
        _books.Remove(delete); 
        System.Console.WriteLine($"Book with id {id} successfully deleted");
    }

    public List<Book> GetBooksByAuthor(int authorID)
    {
        var author=_books.FirstOrDefault(a=>a.AuthorId==authorID); 
        if (author==null)
        {
            System.Console.WriteLine("Could not found author with this id"); 
            return null;
        } 
        return _books.Where(a=>a.AuthorId==authorID).ToList();
    }

    public void UpdateBook(Book book)
    {
         var kitob=_books.FirstOrDefault(a=>a.Id==book.Id); 
         if (kitob==null)
         {
            System.Console.WriteLine("Book not found"); 
            return;
         } 
        kitob.Title=book.Title; 
        kitob.Description=book.Description; 
        kitob.PublicationYear=book.PublicationYear; 
        kitob.PageSize=book.PageSize; 
        kitob.Price=book.Price; 
        kitob.AuthorId=book.AuthorId;
    }
}
