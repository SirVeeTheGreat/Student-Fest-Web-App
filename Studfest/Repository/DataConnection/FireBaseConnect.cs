﻿using Firebase.Auth;
using FireSharp.Interfaces;

namespace Studfest.Repository.DataConnection
{
    public class FireBaseConnect : IDisposable
    {
        public IFirebaseClient firebaseClient;
        public IFirebaseAuthProvider authProvider;


        public FireBaseConnect()
        {
            IFirebaseConfig config = new FireSharp.Config.FirebaseConfig()
            {
                AuthSecret = FireBaseConstants.AuthorizationSecret,
                BasePath = FireBaseConstants.FirebaseDatabaseAddress,

            };

            firebaseClient = new FireSharp.FirebaseClient(config);
            authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(FireBaseConstants.Web_Api));
        }
        
        public void Dispose() { }
    }
}
