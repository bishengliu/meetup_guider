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
  const [countryData, setcountryData] = useState({});
  const [bubbleData, setbubbleData] = useState([]);

  const loadRSVPCities = () => {
    dispatch(getRSVPCitiesActionCreatorAsync());
    setIsLoaded(true);
  };

  const loadCountryTopics = (country: string) => dispatch(getCountryTopicsActionCreatorAsync(country.substring(0, 2)));

  if (!isLoaded) {
    loadRSVPCities();
  }

  useEffect(() => {
    setcountryData(MapDataService.getMapData(heatmapState.rsvpCities));
    setbubbleData(MapDataService.getBubbleData(heatmapState.rsvpCities));

    MapService.drawMap('basic_choropleth', countryData, bubbleData, loadCountryTopics);
  }, [heatmapState]);

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
