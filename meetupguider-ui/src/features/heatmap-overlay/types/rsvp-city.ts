class RSVPCity {
    country: string;

    city: string;

    cityCount: number;

    lat: number;

    lon: number;

    constructor(country: string, city: string, cityCount: number, lat: number, lon: number) {
      this.country = country;
      this.city = city;
      this.cityCount = cityCount;
      this.lat = lat;
      this.lon = lon;
    }
}

export default RSVPCity;
