using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.ApproveComment;
public record ApproveCommentCommand(ApproveLink ApproveLink) : IRequest;