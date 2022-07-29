using System.Text.Json.Serialization;
    public class ObjetoMagico
    {
        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<ObjetoMagico> ObjetosMagicos { get; set; }
    }

    public class EquipmentCategory
    {
        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Rarity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Descripcion
    {
        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("equipment_category")]
        public EquipmentCategory EquipmentCategory { get; set; }

        [JsonPropertyName("rarity")]
        public Rarity Rarity { get; set; }

        [JsonPropertyName("variants")]
        public List<object> Variants { get; set; }

        [JsonPropertyName("variant")]
        public bool Variant { get; set; }

        [JsonPropertyName("desc")]
        public List<string> Descripciones { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

