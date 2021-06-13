import { Action } from 'redux';
import { RSVPCity, CountryTopic } from '../../types';

export interface SetRSVPCitiesAction extends Action {
    rsvpCities: RSVPCity[];
}

export interface SetCountryTopicsAction extends Action {
    countryTopics: CountryTopic[];
}
