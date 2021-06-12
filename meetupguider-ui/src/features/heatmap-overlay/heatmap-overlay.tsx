import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import AppState from '../../redux/app-state';
import { getRSVPCitiesActionCreatorAsync, getCountryTopicsActionCreatorAsync } from './redux/actions/action-creators';

const HeatmapOverlay = (): JSX.Element => {
  const [isLoaded, setIsLoaded] = useState(false);
  const dispatch = useDispatch();
  const heatmapState = useSelector((state: AppState) => state.heatmapState);

  const loadRSVPCities = () => dispatch(getRSVPCitiesActionCreatorAsync());
  // const loadCountryTopics = () => dispatch(getCountryTopicsActionCreatorAsync('nl'));
  if (!isLoaded) {
    loadRSVPCities();
    setIsLoaded(true);
    console.log(heatmapState.rsvpCities);
  }

  return (
    <div>heapmap-overlay</div>
  );
};

export default HeatmapOverlay;
