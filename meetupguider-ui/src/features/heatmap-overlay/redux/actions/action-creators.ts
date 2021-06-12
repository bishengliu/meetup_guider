import { ActionCreator } from 'redux';
import HEATMAP_ACTION_CONSTRANTS from './constants';
import { RSVPCity, CountryTopic } from '../../types';
import { SetRSVPCitiesAction, SetCountryTopicsAction } from './actions';
import store from '../../../../redux/store';
import HeatmapService from '../../services/heatmap-service';

const getRSVPCitiesActionCreatorAsync = (dispatch: typeof store.dispatch): void => {
  HeatmapService
    .getRSVPCities()
    .then((res) => dispatch(getRSVPCitiesActionCreator(res.data)));
};

const getRSVPCitiesActionCreator: ActionCreator<SetRSVPCitiesAction> = (rsvpCities: RSVPCity[]) => (
  {
    type: HEATMAP_ACTION_CONSTRANTS.GET_CITY_RSVPS,
    rsvpCities,
  });

const getCountryTopicsActionCreatorAsync = (country: string) => (dispatch: typeof store.dispatch): void => {
  HeatmapService.getCountryTopics(country)
    .then((res) => dispatch(getCountryTopicsActionCreator(res.data)));
};

const getCountryTopicsActionCreator: ActionCreator<SetCountryTopicsAction> = (countryTopics: CountryTopic[]) => (
  {
    type: HEATMAP_ACTION_CONSTRANTS.GET_COUNTRY_TOPICS,
    countryTopics,
  });

export {
  getRSVPCitiesActionCreatorAsync,
  getCountryTopicsActionCreatorAsync,
};
