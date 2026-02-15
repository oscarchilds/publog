window.leafletInterop = {
    maps: {},

    init: function (elementId, lat, lng, zoom) {
        if (this.maps[elementId]) {
            this.maps[elementId].remove();
        }
        const map = L.map(elementId).setView([lat, lng], zoom);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
            maxZoom: 19
        }).addTo(map);
        this.maps[elementId] = map;

        // Fix map rendering in dynamic containers
        setTimeout(() => map.invalidateSize(), 100);
    },

    addMarker: function (elementId, lat, lng, popupHtml) {
        const map = this.maps[elementId];
        if (!map) return;
        const marker = L.marker([lat, lng]).addTo(map);
        if (popupHtml) {
            marker.bindPopup(popupHtml);
        }
    },

    addMarkers: function (elementId, markers) {
        const map = this.maps[elementId];
        if (!map) return;
        const bounds = [];
        markers.forEach(function (m) {
            const marker = L.marker([m.lat, m.lng]).addTo(map);
            if (m.popupHtml) {
                marker.bindPopup(m.popupHtml);
            }
            bounds.push([m.lat, m.lng]);
        });
        if (bounds.length > 1) {
            map.fitBounds(bounds, { padding: [30, 30] });
        }
    },

    dispose: function (elementId) {
        if (this.maps[elementId]) {
            this.maps[elementId].remove();
            delete this.maps[elementId];
        }
    }
};
