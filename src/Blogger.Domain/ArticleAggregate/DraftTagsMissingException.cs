using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.ArticleAggregate;
public class DraftTagsMissingException() : BlogException("Cannot publish draft without tags.")
{
}
