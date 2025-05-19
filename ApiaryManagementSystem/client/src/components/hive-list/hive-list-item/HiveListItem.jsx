import { Link } from "react-router-dom";
import { formatIsoStringToDisplayDate } from "../../../utils/dateUtils";

export default function HiveListItem({
    hive
}) {
    return (
        <tr>
            <td><Link to={`/hives/${hive._id}/details`}>№{hive.number}</Link></td>
            <td>{hive.type}</td>
            <td>{hive.color}</td>
            <td>{formatIsoStringToDisplayDate(hive.dateBought)}</td>
            <td>{`${hive.apiary.name} - ${hive.apiary.location}`}</td>
        </tr>
    );
};