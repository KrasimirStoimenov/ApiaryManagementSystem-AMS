import { Link } from "react-router-dom";

import { useGetHarvestsCountByHiveId } from "../../../hooks/useHarvests";
import { useGetInspectionsCountByHiveId } from "../../../hooks/useInspections";

import { ListGroup } from "react-bootstrap";

export default function HiveDetailsLinks({
    hiveId,
    hiveBeeQueensCount,
    hiveInspectionsCount,
    hiveDiseasesCount,
    hiveHarvestsCount
}) {
    return (
        <ListGroup className="my-4">
            <ListGroup.Item>
                <Link to={`/hives/${hiveId}/beeQueens`}><strong>Bee Queens:</strong> {hiveBeeQueensCount}</Link>
            </ListGroup.Item>
            <ListGroup.Item>
                <Link to={`/hives/${hiveId}/inspections`}><strong>Inspections:</strong> {hiveInspectionsCount}</Link>
            </ListGroup.Item>
            <ListGroup.Item>
                <Link to={`/hives/${hiveId}/diseases`}><strong>Diseases:</strong> {hiveDiseasesCount}</Link>
            </ListGroup.Item>
            <ListGroup.Item>
                <Link to={`/hives/${hiveId}/harvests`}><strong>Harvests:</strong> {hiveHarvestsCount}</Link>
            </ListGroup.Item>
        </ListGroup>
    );
}