using System;
using PracticalHTML5.Indexes;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace PracticalHTML5
{
    public static class Global
    {
        private static readonly Lazy<IDocumentStore> theDocStore = new Lazy<IDocumentStore>(() =>
        {
            var docStore = new EmbeddableDocumentStore
            {
                DataDirectory = @"~\App_Data\db"
            };
            docStore.Initialize();
            IndexCreation.CreateIndexes(typeof(PlayerStatisticsIndexCreationTask).Assembly, docStore);
            return docStore;
        });

        public static IDocumentStore DocumentStore
        {
            get { return theDocStore.Value; }
        }
    }
}