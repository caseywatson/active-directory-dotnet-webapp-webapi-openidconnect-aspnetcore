namespace TodoListService.Configuration
{
    public class CosmosDbConfiguration
    {
        public string CosmosDbEndpointUri { get; set; }
        public string CosmosDbPrimaryKey { get; set; }

        public string TodoItemDatabaseName { get; set; }
        public string TodoItemCollectionName { get; set; }
    }
}
