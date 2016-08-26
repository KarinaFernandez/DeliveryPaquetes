using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Usuario
    {
        #region variables
        private string nombreUsuario = "";
        private string password = "";
        private bool admin = false;
        private int id = 0;
        private static int ultId = 0;
        #endregion 

        #region properties
        public string NombreUsuario
        {
            get
            {
                return this.nombreUsuario;
            }
            set
            {
                this.nombreUsuario = value;
            }
        }


        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }


        public bool Admin
        {
            get
            {
                return this.admin;
            }
            set
            {
                this.admin = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public static int UltId
        {
            get
            {
                return Cliente.ultId;
            }
            set
            {
                Cliente.ultId = value;
            }
        }
        #endregion

        #region constructor
        public Usuario(string pNombreUsuario, string pPassword)
        {
            this.nombreUsuario = pNombreUsuario;
            this.password = pPassword;
        }

        public Usuario(string pNombreUsuario, string pPassword, bool pAdmin)
        {
            this.nombreUsuario = pNombreUsuario;
            this.password = pPassword;
            this.admin = pAdmin;

            int id = Usuario.UltId + 1;
            Usuario.UltId = id;
            this.id = id;
        }
        #endregion

     }
}