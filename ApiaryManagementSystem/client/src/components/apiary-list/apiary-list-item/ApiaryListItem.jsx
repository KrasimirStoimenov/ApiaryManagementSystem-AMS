export default function ApiaryListItem({
    apiary
}) {
    return (
        <tr>
            <td>{apiary.name}</td>
            <td>{apiary.location}</td>
        </tr>
    );
};