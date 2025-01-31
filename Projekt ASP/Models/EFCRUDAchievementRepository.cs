﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Projekt_ASP.Models
{
    //public interface ICRUDCommentRepository
    //{
    //    Comment Add(Comment comment);
    //    IList<Comment> FindComments(int id);
    //    Comment Update(Comment comment);
    //    void Delete(int id);
    //}
    //public interface ICRUDPostRepository
    //{
    //    Post Add(Post post);
    //    List<Post> FindPosts(int id);
    //    Post Update(Post Post);
    //    void Delete(int id);
    //    Post FindById(int id);
    //    void AddCommentToPost(int CommentId, int PostId);
    //}

    public class EFCRUDAchievementRepository : ICRUDAchievementRepository
    {
        private ApplicationDbContext _context;

        public EFCRUDAchievementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Achievement Add(Achievement achievement)
        {
            EntityEntry<Achievement> entityEntry = _context.Achievements.Add(achievement);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public void AddCommentToAchievement(int CommentID, int AchievementID)
        {
            throw new NotImplementedException();
        }

        public void DeleteAchievement(int id)
        {
            _context.Achievements.Remove(_context.Achievements.Find(id));
            _context.SaveChanges();
        }

        public List<Achievement> FindAll()
        {
            return _context.Achievements.ToList();
        }

        public Achievement FindAchievementById(int id)
        {
            return _context.Achievements.Find(id);
        }

        public List<Achievement> FindPage(int page, int size)
        {
            return (from achievement in _context.Achievements orderby achievement.Name select achievement).Skip(page * size).Take(size).ToList();
        }

        public Achievement Update(Achievement achievement)
        {
            EntityEntry<Achievement> entity = _context.Achievements.Update(achievement);
            _context.SaveChanges();
            return entity.Entity;

        }
        public void AddPostToAchievement(int PostId, int AchievementId)
        {
            var post = _context.Posts.Find(PostId);
            var achievement = _context.Achievements.Find(AchievementId);
            achievement.Posts.Add(post);
            Update(achievement);
        }
        public Post Add(Post post)
        {
            EntityEntry<Post> entityEntry = _context.Posts.Add(post);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public List<Post> FindPosts(int id)
        {
            IEnumerable<Post> postsQuery = from Post in _context.Posts where Post.Achievement.Id == id select Post;
            return postsQuery.ToList();
        }

        public Post Update(Post Post)
        {
            EntityEntry<Post> entity = _context.Posts.Update(Post);
            _context.SaveChanges();
            return entity.Entity;
        }
        public void DeletePost(int id)
        {
            _context.Posts.Remove(_context.Posts.Find(id));
            _context.SaveChanges();
        }

        public Post FindPostById(int id)
        {
            return _context.Posts.Find(id);
        }
        public void AddCommentToPost(int CommentId, int PostId)
        {
            var post = _context.Posts.Find(PostId);
            var comment = _context.Comments.Find(CommentId);
            post.Comments.Add(comment);
            Update(post);
        }
        public Comment Add(Comment comment)
        {
            EntityEntry<Comment> entityEntry = _context.Comments.Add(comment);
            _context.SaveChanges();
            return entityEntry.Entity;
        }
        public Comment FindCommnetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> FindComments(int id)
        {
            IEnumerable<Comment> commentsQuery = from Comment in _context.Comments where Comment.Post.Id == id select Comment;
            return commentsQuery.ToList();
        }
        public void DeleteComment(int id)
        {
            _context.Comments.Remove(_context.Comments.Find(id));
            _context.SaveChanges();
        }
    }
    //public class EFCRUDECommentRepository : ICRUDCommentRepository
    //{
    //    private ApplicationDbContext _context;

    //    public EFCRUDECommentRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public Comment Add(Comment comment)
    //    {
    //        EntityEntry<Comment> entityEntry = _context.Comments.Add(comment);
    //        _context.SaveChanges();
    //        return entityEntry.Entity;
    //    }
    //    public Comment Update(Comment comment)
    //    {
    //        EntityEntry<Comment> entity = _context.Comments.Update(comment);
    //        _context.SaveChanges();
    //        return entity.Entity;
    //    }

    //    public IList<Comment> FindComments(int id)
    //    {
    //        IEnumerable<Comment> commentsQuery = from Comment in _context.Comments where Comment.Post.Id == id select Comment;
    //        return commentsQuery.ToList();
    //    }
    //    public void Delete(int id)
    //    {
    //        _context.Comments.Remove(_context.Comments.Find(id));
    //        _context.SaveChanges();
    //    }
    //}
    //public class EFCRUDEPostRepository : ICRUDPostRepository
    //{
    //    private ApplicationDbContext _context;
    //    public EFCRUDEPostRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public Post Add(Post post)
    //    {
    //        EntityEntry<Post> entityEntry = _context.Posts.Add(post);
    //        _context.SaveChanges();
    //        return entityEntry.Entity;
    //    }

    //    public List<Post> FindPosts(int id)
    //    {
    //        IEnumerable<Post> postsQuery = from Post in _context.Posts where Post.Achievement.Id == id select Post;
    //        return postsQuery.ToList();
    //    }

    //    public Post Update(Post Post)
    //    {
    //        EntityEntry<Post> entity = _context.Posts.Update(Post);
    //        _context.SaveChanges();
    //        return entity.Entity;
    //    }
    //    public void Delete(int id)
    //    {
    //        _context.Posts.Remove(_context.Posts.Find(id));
    //        _context.SaveChanges();
    //    }

    //    public Post FindById(int id)
    //    {
    //        return _context.Posts.Find(id);
    //    }
    //    public void AddCommentToPost(int CommentId, int PostId)
    //    {
    //        var post = _context.Posts.Find(PostId);
    //        var comment = _context.Comments.Find(CommentId);
    //        post.Comments.Add(comment);
    //        Update(post);
    //    }
    //}

}
