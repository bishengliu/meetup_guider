class CountryTopic {
    country: string;

    city: string;

    lat: number;

    lon: number;

    topicName: string;

    topicCount: number;

    constructor(country: string, city: string, lat: number, lon: number, topicName: string, topicCount: number) {
      this.country = country;
      this.city = city;
      this.lat = lat;
      this.lon = lon;
      this.topicCount = topicCount;
      this.topicName = topicName;
    }
}

export default CountryTopic;
