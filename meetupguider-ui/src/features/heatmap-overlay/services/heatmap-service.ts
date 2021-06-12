import { AxiosPromise } from 'axios';
import httpService from '../../../services/http-service';

const getRSVPCities = (): AxiosPromise => httpService({
  url: '/guider',
  method: 'GET',
});

const getCountryTopics = (country: string): AxiosPromise => httpService({
  url: `/guider/${country}`,
  method: 'GET',
});

const HeatmapService = {
  getRSVPCities,
  getCountryTopics,
};

export default HeatmapService;
