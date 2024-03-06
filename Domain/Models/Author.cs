namespace Domain;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Nationality { get; set; }
    public List<Book> Books { get; set; }
}
