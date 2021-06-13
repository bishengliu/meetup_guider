import { combineReducers, Reducer } from 'redux';
import AppState from './app-state';
import HeatmapReducer from '../features/heatmap-overlay/redux/reducer';

const RootReducer: Reducer<AppState> = combineReducers<AppState>({ heatmapState: HeatmapReducer });

export default RootReducer;
