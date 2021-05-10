using Main.Data.repositories;
using Main.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private bool IsDisposed = false;

        protected ApplicationDBEntities context;

        protected GameRepository gameRepository;
        protected UserGameRepository userGameRepository;
        protected UserRepository userRepository;

        public GameRepository GameRepository
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(context);
                return gameRepository;
            }
        }

        public UserGameRepository UserGameRepository
        {
            get
            {
                if (userGameRepository == null)
                    userGameRepository = new UserGameRepository(context);
                return userGameRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }

        public void SaveChanges() => context.SaveChanges();
        public void SaveChangesAsync() => context.SaveChangesAsync();

        public UnitOfWork()
        {
            context = new ApplicationDBEntities();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
