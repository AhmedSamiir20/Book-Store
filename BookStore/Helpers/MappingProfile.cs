namespace BookStore.Helpers;

public class MappingProfile:Profile
{
	public MappingProfile()
	{
		CreateMap<Book,BooksDetailsDto>();	
	}
}
