import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import {
  Table, Container, Row, Col, Alert, Spinner,
} from 'react-bootstrap';
import './heatmap-overlay.css';
import AppState from '../../redux/app-state';
import MapDataService from './services/mapdata-service';
import MapService from './services/map-service';
import { getRSVPCitiesActionCreatorAsync, getCountryTopicsActionCreatorAsync } from './redux/actions/action-creators';

const HeatmapOverlay = (): JSX.Element => {
  const [isLoaded, setIsLoaded] = useState(false);

  const dispatch = useDispatch();

  const heatmapState = useSelector((state: AppState) => state.heatmapState);

  // function to load heatmap data
  const loadRSVPCities = () => dispatch(getRSVPCitiesActionCreatorAsync());

  if (!isLoaded) {
    loadRSVPCities();
    setIsLoaded(true);
  }

  useEffect(() => {
    // function to load country trending topics
    const loadCountryTopics = (country: string) => dispatch(getCountryTopicsActionCreatorAsync(country.substring(0, 2)));

    // draw geo-heatmap
    MapService.drawMap('basic_choropleth', // id
      MapDataService.getMapData(heatmapState.rsvpCities), // heatmap data
      MapDataService.getBubbleData(heatmapState.rsvpCities), // bubble data
      loadCountryTopics); // click callback
  }, [dispatch, heatmapState.rsvpCities, isLoaded]);

  return (
    <Container fluid>
      {/* loading alert */}
      <Row>
        <Col>
          { !isLoaded && heatmapState.rsvpCities.length === 0 && (
            <div className="guider_loading"><Spinner animation="grow" variant="primary" /></div>)}
        </Col>
      </Row>

      <Row>
        {/* table displayed upon clicking on the country */}
        <Col xs lg="2">
          {
            isLoaded && heatmapState.countryTopics.length === 0 && (
            <Alert variant="info">click a country to load the trending topics.</Alert>)
          }

          { heatmapState.countryTopics.length > 0 && (
            <Table striped bordered hover size="sm" responsive>
              <thead>
                <tr>
                  <th>Topic</th>
                  <th>Count</th>
                  <th>City</th>
                </tr>
              </thead>
              <tbody>
                { heatmapState.countryTopics.map((ct) => (
                  <tr>
                    <td>{ ct.topicName }</td>
                    <td>{ ct.topicCount }</td>
                    <td>{ ct.city }</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          )}

        </Col>

        {/* the geo-heatmap svg */}
        <Col md="auto">
          <div id="basic_choropleth" className="heatmap_guider" data-testid="meetup-guider-heatmap" />
        </Col>
      </Row>
    </Container>
  );
};

export default HeatmapOverlay;
