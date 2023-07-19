namespace InterfaceSegregation{
    public class Cloud : ICloudActivities, IDeveloperActivities
    {
        public void DeployApp()
        {
            Console.WriteLine("Deploying app to cloud");
        }

        public void Develop(){
            Console.WriteLine("I'm developing the functionalities required");
        }
    }
}