import { Reducer, Action } from 'redux';
import HeatmapState from './state';
import HEATMAP_ACTION_CONSTRANTS from './actions/constants';
import { SetRSVPCitiesAction, SetCountryTopicsAction } from './actions/actions';

const initState: HeatmapState = { rsvpCities: [], countryTopics: [] };

const HeatmapReducer: Reducer<HeatmapState> = (state: HeatmapState = initState, action: Action): HeatmapState => {
  switch (action.type) {
    case HEATMAP_ACTION_CONSTRANTS.GET_CITY_RSVPS: {
      const { rsvpCities } = action as SetRSVPCitiesAction;
      return {
        ...state,
        rsvpCities,
      };
    }
    case HEATMAP_ACTION_CONSTRANTS.GET_COUNTRY_TOPICS: {
      const { countryTopics } = action as SetCountryTopicsAction;
      return {
        ...state,
        countryTopics,
      };
    }
    default:
      return state;
  }
};

export default HeatmapReducer;
