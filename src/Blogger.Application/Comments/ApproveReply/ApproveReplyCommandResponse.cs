using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.ApproveReply;

public record ApproveReplyCommandResponse(ArticleId ArticleId, CommentId CommentId, ReplyId ReplyId) : IRequest;