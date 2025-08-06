import { Link } from "react-router-dom";
import { formatIsoStringToDisplayDate } from "../../../utils/dateUtils";

export default function HiveListItem({
    hive
}) {
    return (
        <tr>
            <td><Link to={`/hives/${hive.id}/details`}>№{hive.number}</Link></td>
            <td>{hive.type}</td>
            <td>{hive.status}</td>
            <td>{hive.color}</td>
            <td>{hive.dateBought}</td>
            <td>{hive.apiaryId}</td>
        </tr>
    );
};