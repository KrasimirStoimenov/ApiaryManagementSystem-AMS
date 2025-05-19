import { Button, Modal } from 'react-bootstrap';

export default function Delete(
    {
        onClose,
        onDelete,
        isDeleting
    }
) {
    return (
        <Modal show={true} onHide={() => onClose()}>
            <Modal.Header closeButton>
                <Modal.Title>Confirm Delete</Modal.Title>
            </Modal.Header>
            <Modal.Body>Are you sure you want to delete this item?</Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={() => onClose()} disabled={isDeleting}>Cancel</Button>
                <Button variant="danger" onClick={() => onDelete()} disabled={isDeleting}>{isDeleting ? 'Deleting...' : 'Delete'}</Button>
            </Modal.Footer>
        </Modal>
    );
};