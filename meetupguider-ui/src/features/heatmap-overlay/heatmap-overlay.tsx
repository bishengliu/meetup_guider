import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import './heatmap-overlay.css';
// @ts-ignore
import AppState from '../../redux/app-state';
import MapDataService from './services/mapdata-service';
import MapService from './services/map-service';
import { getRSVPCitiesActionCreatorAsync, getCountryTopicsActionCreatorAsync } from './redux/actions/action-creators';

const HeatmapOverlay = (): JSX.Element => {
  const [isLoaded, setIsLoaded] = useState(false);
  const dispatch = useDispatch();
  const heatmapState = useSelector((state: AppState) => state.heatmapState);

  // dispatch rsvps
  const loadRSVPCities = () => dispatch(getRSVPCitiesActionCreatorAsync());

  if (!isLoaded) {
    loadRSVPCities();
    setIsLoaded(true);
  }

  useEffect(() => {
    // load country trending topics
    const loadCountryTopics = (country: string) => dispatch(getCountryTopicsActionCreatorAsync(country.substring(0, 2)));

    MapService.drawMap('basic_choropleth',
      MapDataService.getMapData(heatmapState.rsvpCities),
      MapDataService.getBubbleData(heatmapState.rsvpCities),
      loadCountryTopics);
  }, [dispatch, heatmapState.rsvpCities, isLoaded]);

  return (
    <div>
      <div
        id="basic_choropleth"
        style={{ position: 'relative', width: 'auto%', height: '30%' }}
        className="heatmap_guider"
      />
      {
        heatmapState.rsvpCities.length === 0 && (<div>loading</div>)
      }
    </div>

  );
};

export default HeatmapOverlay;
