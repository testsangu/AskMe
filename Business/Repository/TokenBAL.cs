using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.AskUs;

namespace Business.Repository
{
   public class TokenBAL
    {
        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Token GenerateToken(int userId)
        {
            using (var _context = new AskUsDbContext())
            {
                string token = Guid.NewGuid().ToString();
                DateTime issuedOn = DateTime.Now;
                DateTime expiredOn = DateTime.Now.AddSeconds(3000);//(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                var tokendomain = new Token
                {
                    UserId = userId,
                    AuthToken = token,
                    IssuedOn = issuedOn,
                    ExpiresOn = expiredOn
                };

                List<Token> tokens = _context.Tokens.Where(x => x.UserId == userId).ToList();
                foreach (Token t in tokens)
                {
                    _context.Tokens.Remove(t);
                }
                
                _context.Tokens.Add(tokendomain);
                _context.SaveChanges();
                return tokendomain;
            }
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            using (var _context = new AskUsDbContext())
            {
                var token = _context.Tokens.Where(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now).FirstOrDefault();
                if (token != null && !(DateTime.Now > token.ExpiresOn))
                {
                    token.ExpiresOn = token.ExpiresOn.AddSeconds(3000);//(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                    _context.Entry(token).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();                    
                    return true;
                }
                return false;
            }
        }

        //public UserDTO GetUserByToken(string tokenId)
        //{            
        //    var token = uow.Tokens.GetAll().Where(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now).FirstOrDefault().UserId;

        //    repofactory.GetRepositoryFactoryForEntityType<User>();
        //    repoProvider = new RepositoryProvider(repofactory);
        //    uow = new AscendLearningUnitofWork(repoProvider);
        //    UserDTO user = EntityToDTOMapper.UserToUserDTO(uow.Users.GetAll().Where(x => x.UserID == token).FirstOrDefault());
        //    return user;
        //}
    }
}
