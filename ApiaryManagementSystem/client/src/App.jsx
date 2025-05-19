import { Routes, Route } from 'react-router-dom'

import 'bootstrap-icons/font/bootstrap-icons.css';
import 'react-toastify/dist/ReactToastify.css';
import './App.css';

import { AuthContextProvider } from './contexts/AuthContext';
import { HiveContextProvider } from './contexts/HiveContext';

import Container from 'react-bootstrap/esm/Container'

import Home from './components/home/Home'
import Header from './components/header/Header'
import HiveDetails from './components/hive-details/HiveDetails';
import HiveAdd from './components/hive-add/HiveAdd';
import BeeQueenList from './components/beeQueen-list/BeeQueenList';
import Login from './components/login/Login';
import Register from './components/register/Register';
import Logout from './components/logout/Logout';
import ApiaryAdd from './components/home/apiary-list/apiary-add/ApiaryAdd';
import HiveInspectionList from './components/hive-details/hive-inspection-list/HiveInspectionList';
import HiveInspectionAdd from './components/hive-details/hive-inspection-list/hive-inspection-add/HiveInspectionAdd';
import HiveHarvestList from './components/hive-details/hive-harvest-list/HiveHarvestList';
import HiveHarvestAdd from './components/hive-details/hive-harvest-list/hive-harvest-add/HiveHarvestAdd';
import HiveBeeQueenList from './components/hive-details/hive-beeQueen-list/HiveBeeQueenList';
import HiveBeeQueenAdd from './components/hive-details/hive-beeQueen-list/hive-beeQueen-add/HiveBeeQueenAdd';
import HiveBeeQueenEdit from './components/hive-details/hive-beeQueen-list/hive-beeQueen-edit/HiveBeeQueenEdit';
import HiveEdit from './components/hive-details/hive-edit/HiveEdit';
import HiveInspectionEdit from './components/hive-details/hive-inspection-list/hive-inspection-edit/HiveInspectionEdit';
import HiveHarvestEdit from './components/hive-details/hive-harvest-list/hive-harvest-edit/HiveHarvestEdit';
import PrivateRoutes from './components/common/PrivateRoutes';
import GuestRoutes from './components/common/GuestRoutes';
import HiveList from './components/hive-list/HiveList';
import ApiaryList from './components/apiary-list/ApiaryList';
import InspectionList from './components/inspection-list/InspectionList';
import HarvestList from './components/harvest-list/HarvestList';
import { ToastContainer } from 'react-toastify';

function App() {
    return (
        <AuthContextProvider>
            <ToastContainer theme='colored' />

            <Header />

            <Container>
                <Routes>
                    <Route path='/' element={<Home />} />
                    <Route element={<GuestRoutes />} >
                        <Route path='/login' element={<Login />} />
                        <Route path='/register' element={<Register />} />
                    </Route>
                    <Route element={<PrivateRoutes />}>
                        <Route path='/logout' element={<Logout />} />
                        <Route path='/apiaries/add' element={<ApiaryAdd />} />
                        <Route path='/apiaries/:apiaryId/hives/add' element={<HiveAdd />} />
                        <Route path='/apiaries' element={<ApiaryList />} />
                        <Route path='/hives' element={<HiveList />} />
                        <Route path='/beeQueens' element={<BeeQueenList />} />
                        <Route path='/inspections' element={<InspectionList />} />
                        <Route path='/harvests' element={<HarvestList />} />
                        <Route element={<HiveContextProvider />}>
                            <Route path='/hives/:hiveId/details' element={<HiveDetails />} />
                            <Route path='/hives/:hiveId/inspections' element={<HiveInspectionList />} />
                            <Route path='/hives/:hiveId/inspections/add' element={<HiveInspectionAdd />} />
                            <Route path='/hives/:hiveId/harvests' element={<HiveHarvestList />} />
                            <Route path='/hives/:hiveId/harvests/add' element={<HiveHarvestAdd />} />
                            <Route path='/hives/:hiveId/beeQueens' element={<HiveBeeQueenList />} />
                            <Route path='/hives/:hiveId/beeQueens/add' element={<HiveBeeQueenAdd />} />
                            <Route path='/hives/:hiveId/edit' element={<HiveEdit />} />
                            <Route path='/harvests/:harvestId/edit' element={<HiveHarvestEdit />} />
                            <Route path='/beeQueens/:beeQueenId/edit' element={<HiveBeeQueenEdit />} />
                            <Route path='/inspections/:inspectionId/edit' element={<HiveInspectionEdit />} />
                        </Route>
                    </Route>
                </Routes>
            </Container>
        </AuthContextProvider>
    )
}

export default App
