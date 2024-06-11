namespace Section01 {
    internal class Employee {
        private string v;
        private string a;

        public string Name { get; set; }
        public int Id { get; set; }

        public Employee(int id, string name) {
            Id = id;
            Name = name;

        }

        public Employee(string v, string a) {
            this.v = v;
            this.a = a;
        }
    }
}