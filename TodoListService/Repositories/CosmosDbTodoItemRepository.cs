using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListService.Configuration;
using TodoListService.Interfaces;
using TodoListService.Models;

namespace TodoListService.Repositories
{
    public class CosmosDbTodoItemRepository : ITodoItemRepository
    {
        private readonly DocumentClient documentClient;
        private readonly Uri todoCollectionUri;

        public CosmosDbTodoItemRepository(IOptions<CosmosDbConfiguration> configurationOptions)
        {
            var configuration = configurationOptions.Value;

            documentClient = new DocumentClient(new Uri(configuration.CosmosDbEndpointUri), configuration.CosmosDbPrimaryKey);
            todoCollectionUri = UriFactory.CreateDocumentCollectionUri(configuration.TodoItemDatabaseName, configuration.TodoItemCollectionName);
        }

        public Task<IEnumerable<TodoItem>> GetUserItemsAsync(string itemOwner)
        {
            var todoItems = documentClient.CreateDocumentQuery<TodoItem>(todoCollectionUri)
                .Where(i => (i.Owner == itemOwner));

            return Task.FromResult(todoItems.ToList() as IEnumerable<TodoItem>);
        }

        public async Task AddItemAsync(TodoItem todoItem)
        {
            await documentClient.CreateDocumentAsync(todoCollectionUri, todoItem);
        }
    }
}
