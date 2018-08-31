namespace Hstar.Lara.Swagger
{
    public class ApiInfo
    {
        /// <summary>
        /// The API name, must equal to assembly name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Api version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Contact name
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Project url
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }
    }
}