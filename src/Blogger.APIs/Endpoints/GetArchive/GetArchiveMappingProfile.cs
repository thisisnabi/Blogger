namespace Blogger.APIs.Contracts.GetArchive;

public class GetArchiveMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetArchiveQueryResponse, GetArchiveResponse>()
                    .Map(x => x.Date, src => $"{src.Year} {GetMonthName(src.Month)}")
                    .Map(x => x.Items, src => src.Articles.ToImmutableArray());
    }

    private string GetMonthName(int monthNumber)
    {
        DateTime date = new DateTime(2000, monthNumber, 1);
        return date.ToString("MMMM");
    }
}